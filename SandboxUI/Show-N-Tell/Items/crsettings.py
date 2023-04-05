import pyperclip

filepath = r'C:\Users\bmartin\source\repos\Perl-Pi\Db\Pi.DbLayer\Global\MachineSettings\MachineSettings.cs'


def itemstostr(items):
    matchitems = [('Min', 'n/a'), ('Max', 'n/a'), ('Default', 'n/a')]
    for item in items:
        for i in range(len(matchitems)):
            if matchitems[i][0] in item:
                matchitems[i] = (matchitems[i][0], item.split('= ')[1])
    output = ''
    for matchitem in matchitems:
        output += matchitem[0] + ': ' + matchitem[1] + ', '
    return ' (' + output[:-2] + ')\n'


with open(filepath) as fp:
    line = fp.readline()
    lastsubgroup = ''
    outputstr = ''
    while line:
        if 'Group = "CutAndRoll"' in line:
            line = line.strip()
            items = line[:-2].split(', ')[1:]
            thissubgroup = items[0].split('"')[1]
            if thissubgroup != lastsubgroup:
                outputstr += '\n***' + thissubgroup + '***\n'
                lastsubgroup = thissubgroup
            outputstr += ('(unused) ' if line[0:2] == '//' else '') + \
                fp.readline().strip().split(' ')[3] + itemstostr(items)
        line = fp.readline()
    pyperclip.copy(outputstr)
    print(outputstr)
